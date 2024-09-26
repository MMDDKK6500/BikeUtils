# ✨BikeUtils✨
Uma lib de utilidades para plugins de EXILED, criado pro Bicicleta e atualizado por MMDDKK6500.

É utilizado no servidor brasileiro Danger Containment

# Como utilizar

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