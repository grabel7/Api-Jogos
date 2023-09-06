# Api Jogos
 Minha primeira API

# Como usar
A API foi escrita utilizando Visual Studio Code. Para utilizá-la, abra o programa e em seguida um terminal. 
1: No terminal, digite "dotnet run" e copie a porta do primeiro localhost que aparecer.
2: Em seguida, digite "httprepl https://localhost:{PORTA}" substituindo o {PORTA} pela porta que você copiou do localhost.
3: Envie "ls" e em seguida digite "cd Jogos"
4: Você pode testar enviar um GET para ver se ela está funcionadno.

# Utilidade
A API é um código básico de armazenamento de jogos. Ela guarda dados como: Id (Primary Key), nome do jogo, se está disponível para venda, quantas vendas foram efetuadas, quando a entrada foi criada com o PUT, um GUID, e o histórico de edições feitas com descrição e data da alteração. 