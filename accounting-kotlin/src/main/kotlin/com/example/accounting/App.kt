package com.example.accounting

import org.slf4j.LoggerFactory

fun main(args: Array<String>) {
    val logger = LoggerFactory.getLogger("App")
    logger.info("Starting Accounting CLI")

    val cli = Cli()
    cli.run(args)
}
