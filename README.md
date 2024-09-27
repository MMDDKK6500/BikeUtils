# ✨BikeUtils✨
Uma lib de utilidades para plugins de EXILED, criado pro Bicicleta e atualizado por MMDDKK6500.

É utilizado no servidor brasileiro Danger Containment

# Como colaborar
## Importando as assemblies do SCPSL

Crie o arquivo `BikeUtils.csproj.user` no mesmo local que `BikeUtils.csproj` e coloque isso dentro:
```xml
<Project>
    <PropertyGroup>
        <EXILED_REFERENCES>../include</EXILED_REFERENCES>
    </PropertyGroup>
</Project>
```
Mude o `../include` para a pasta onde guarda todas as assemblies do SCPSL, pode ser um caminho relativo ao arquivo, como o exemplo demonstra, ou pode ser um caminho absoluto como `C:\Program Files (x86)\Steam\steamapps\common\SCP Secret Laboratory Dedicated Server\SCPSL_Data\Managed` (Local padrão onde fica os arquivos do SCPSL Dedicated Server)

No caso dessa lib, se utiliza as assemblies `Assembly-CSharp`, `Mirror` e `UnityEngine.CoreModule`, que já vem com o servidor dedicado.

## Utilizando o codemgr.cmd (Windows e VS Code apenas)
#### **AS PESSOAS UTILIZANDO Visual Studio ou Linux não precisam seguir essa etapa**
#### *Ele tambem não é necessário caso você saiba usar a dotnet CLI.*

`codemgr.cmd` é um scriptzinho que MMDDKK6500 fez originalmente para a zDarkneSz Network para ajudar no gerenciamento de projetos, ele é baseado em Batch, utilizando a dotnet CLI.

Quando utilizado sem nenhum parâmetro ele mostra a tela de ajuda:
```
Hi! This script was made by MMDDKK6500 for use with plugin source code management
usage: codemanager [command] (arguments)

Commands available:
   build   Will run the build.cmd script(runs check.cmd)
   clean   Will run the dotnet clean command
   commit  Will stage, commit and push every change into github!
```

Utilize `codemgr build` para compilar o projeto.<br>
Ou então utilize `codemgr commit` para dar commit no projeto, **ISSO APENAS FUNCIONA COM COLABORADORES OFICIAIS!!!**