Exemplos para geração do Code First.

Utilizar "Package Manager Console"

-Selecionar o projeto correspondendo

Sequência de comandos:

1 - Add-Migration <NameMigration>										*Criar um migration com o nome correspondente a alteração*
2 - Update-Database														*Faz as alterações no database*
3 - Script-Migration -From <PreviousMigration> -To <LastMigration>		*Gera script sql. Necessário salvar na pasta Database na raiz do projeto*