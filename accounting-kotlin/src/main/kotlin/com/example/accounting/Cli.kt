package com.example.accounting

import com.example.accounting.db.DatabaseFactory
import com.example.accounting.services.AccountService
import com.example.accounting.services.JournalService

class Cli {
    private val accountService = AccountService()
    private val journalService = JournalService()

    fun run(args: Array<String>) {
        DatabaseFactory.init()
        if (args.isEmpty()) {
            println("Accounting CLI - commands:\n" +
                "  init-db\n" +
                "  add-account <code> <name> <type>\n" +
                "  list-accounts\n" +
                "  add-entry <date YYYY-MM-DD> <debitAccount> <creditAccount> <amount> <memo>\n" +
                "  trial-balance\n")
            return
        }
        when (args[0]) {
            "init-db" -> DatabaseFactory.createSchema()
            "add-account" -> {
                val code = args.getOrNull(1) ?: return println("Missing code")
                val name = args.getOrNull(2) ?: return println("Missing name")
                val type = args.getOrNull(3) ?: return println("Missing type")
                accountService.createAccount(code, name, type)
            }
            "list-accounts" -> accountService.listAccounts().forEach { println(it) }
            "add-entry" -> {
                val date = args.getOrNull(1) ?: return println("Missing date")
                val debit = args.getOrNull(2) ?: return println("Missing debit account")
                val credit = args.getOrNull(3) ?: return println("Missing credit account")
                val amount = args.getOrNull(4)?.toBigDecimalOrNull() ?: return println("Invalid amount")
                val memo = args.drop(5).joinToString(" ")
                journalService.addSimpleEntry(date, debit, credit, amount, memo)
            }
            "trial-balance" -> journalService.printTrialBalance()
            else -> println("Unknown command: ${args[0]}")
        }
    }
}
