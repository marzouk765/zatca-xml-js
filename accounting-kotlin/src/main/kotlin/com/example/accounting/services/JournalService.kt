package com.example.accounting.services

import com.example.accounting.tables.JournalEntries
import com.example.accounting.tables.JournalLines
import com.example.accounting.tables.Accounts
import org.jetbrains.exposed.sql.*
import org.jetbrains.exposed.sql.transactions.transaction
import java.math.BigDecimal

class JournalService {
    private val accountService = AccountService()

    fun addSimpleEntry(date: String, debitAccountCode: String, creditAccountCode: String, amount: BigDecimal, memo: String) {
        val debitId = accountService.findAccountIdByCode(debitAccountCode)
            ?: error("Debit account not found: $debitAccountCode")
        val creditId = accountService.findAccountIdByCode(creditAccountCode)
            ?: error("Credit account not found: $creditAccountCode")

        transaction {
            val entryId = JournalEntries.insertAndGetId {
                it[JournalEntries.date] = date
                it[JournalEntries.memo] = memo
            }.value

            JournalLines.insert {
                it[JournalLines.entryId] = entryId
                it[JournalLines.accountId] = debitId
                it[JournalLines.side] = "DEBIT"
                it[JournalLines.amount] = amount
            }
            JournalLines.insert {
                it[JournalLines.entryId] = entryId
                it[JournalLines.accountId] = creditId
                it[JournalLines.side] = "CREDIT"
                it[JournalLines.amount] = amount
            }
        }
    }

    fun printTrialBalance() {
        val totals = transaction {
            val debitSums = JournalLines
                .slice(JournalLines.accountId, JournalLines.amount.sum())
                .select { JournalLines.side eq "DEBIT" }
                .groupBy(JournalLines.accountId)
                .associate { it[JournalLines.accountId].value to (it[JournalLines.amount.sum()] ?: BigDecimal.ZERO) }

            val creditSums = JournalLines
                .slice(JournalLines.accountId, JournalLines.amount.sum())
                .select { JournalLines.side eq "CREDIT" }
                .groupBy(JournalLines.accountId)
                .associate { it[JournalLines.accountId].value to (it[JournalLines.amount.sum()] ?: BigDecimal.ZERO) }

            Accounts.selectAll().associate { row ->
                val id = row[Accounts.id].value
                val name = row[Accounts.name]
                val code = row[Accounts.code]
                val debit = debitSums[id] ?: BigDecimal.ZERO
                val credit = creditSums[id] ?: BigDecimal.ZERO
                val balance = debit - credit
                id to Triple(code, name, balance)
            }
        }

        println("Trial Balance:")
        var totalDebit = BigDecimal.ZERO
        var totalCredit = BigDecimal.ZERO
        totals.values.sortedBy { it.first }.forEach { (code, name, balance) ->
            if (balance >= BigDecimal.ZERO) {
                totalDebit += balance
                println("$code | $name | Debit: $balance")
            } else {
                val credit = balance.negate()
                totalCredit += credit
                println("$code | $name | Credit: $credit")
            }
        }
        println("Totals -> Debit: $totalDebit | Credit: $totalCredit")
    }
}
