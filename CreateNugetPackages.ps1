$ErrorActionPreference = 'Stop'
Remove-Item -Force ./dist/*nupkg -ErrorAction Ignore
nuget pack PathHelper.csproj -OutputDirectory dist -Prop Configuration=Release
