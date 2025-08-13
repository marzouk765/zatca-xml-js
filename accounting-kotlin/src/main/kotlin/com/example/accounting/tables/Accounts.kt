package com.example.accounting.tables

import org.jetbrains.exposed.dao.id.IntIdTable

object Accounts : IntIdTable("accounts") {
    val code = varchar("code", 32).uniqueIndex()
    val name = varchar("name", 128)
    val type = varchar("type", 32) // Asset, Liability, Equity, Revenue, Expense
}
