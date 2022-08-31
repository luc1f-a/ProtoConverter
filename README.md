This script can help you transform .NET classes with properties to .proto files

## Settings:
- "PathToDll" - Shift + Right Mouse Button on the needed dll and then tap "Copy as path"
- "Namespace" - option `csharp_namespace`
- "Package" - package name for proto
- "ClassesToImport" - which classes need to import


## Example

```json

{
  "PathToDll": "C:\Users\User\source\someProgram\bin\Debug\net6.0\SomeProgram.dll",
  "Namespace": "SomeLibrary.Domain",
  "Package": "Domain",
  "ClassesToImport": ["Model1", "Model2", "Model3"]
}
```
