plugins {
    kotlin("jvm") version "2.0.20"
    application
}

repositories {
    mavenCentral()
}

val ktorVersion = "3.0.0"
val exposedVersion = "0.53.0"
val sqliteVersion = "3.46.0.0"
val logbackVersion = "1.5.8"
dependencies {
    implementation(kotlin("stdlib"))

    // Exposed and SQLite
    implementation("org.jetbrains.exposed:exposed-core:$exposedVersion")
    implementation("org.jetbrains.exposed:exposed-dao:$exposedVersion")
    implementation("org.jetbrains.exposed:exposed-jdbc:$exposedVersion")
    implementation("org.xerial:sqlite-jdbc:$sqliteVersion")

    // Logging via SLF4J + Logback
    implementation("ch.qos.logback:logback-classic:$logbackVersion")

    testImplementation(kotlin("test"))
}

kotlin {
    jvmToolchain(21)
}

application {
    mainClass.set("com.example.accounting.AppKt")
}

