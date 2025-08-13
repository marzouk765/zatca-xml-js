package com.example.accounting.services

import com.example.accounting.tables.Accounts
import org.jetbrains.exposed.sql.*
import org.jetbrains.exposed.sql.transactions.transaction

data class AccountDto(val id: Int, val code: String, val name: String, val type: String)

class AccountService {
    fun createAccount(code: String, name: String, type: String): Int = transaction {
        Accounts.insertAndGetId {
            it[Accounts.code] = code
            it[Accounts.name] = name
            it[Accounts.type] = type
        }.value
    }

    fun listAccounts(): List<AccountDto> = transaction {
        Accounts.selectAll().orderBy(Accounts.code to SortOrder.ASC).map {
            AccountDto(
                id = it[Accounts.id].value,
                code = it[Accounts.code],
                name = it[Accounts.name],
                type = it[Accounts.type]
            )
        }
    }

    fun findAccountIdByCode(code: String): Int? = transaction {
        Accounts.slice(Accounts.id).select { Accounts.code eq code }.limit(1).firstOrNull()?.get(Accounts.id)?.value
    }
}
