package com.example.accounting.db

import org.slf4j.LoggerFactory
import org.jetbrains.exposed.sql.Database
import org.jetbrains.exposed.sql.SchemaUtils
import org.jetbrains.exposed.sql.transactions.transaction
import com.example.accounting.tables.Accounts
import com.example.accounting.tables.JournalEntries
import com.example.accounting.tables.JournalLines

object DatabaseFactory {
    private val logger = LoggerFactory.getLogger(DatabaseFactory::class.java)

    fun init() {
        Database.connect("jdbc:sqlite:accounting.db", driver = "org.sqlite.JDBC")
        logger.info("Connected to SQLite database accounting.db")
    }

    fun createSchema() {
        transaction {
            SchemaUtils.create(Accounts, JournalEntries, JournalLines)
        }
        logger.info("Database schema created")
    }
}
