package com.example.accounting.tables

import org.jetbrains.exposed.dao.id.IntIdTable
import org.jetbrains.exposed.sql.ReferenceOption

object JournalEntries : IntIdTable("journal_entries") {
    val date = varchar("date", 10) // YYYY-MM-DD
    val memo = varchar("memo", 255).default("")
}

object JournalLines : IntIdTable("journal_lines") {
    val entryId = reference("entry_id", JournalEntries, onDelete = ReferenceOption.CASCADE)
    val accountId = reference("account_id", Accounts)
    val side = varchar("side", 6) // DEBIT or CREDIT
    val amount = decimal("amount", 18, 2)
}
