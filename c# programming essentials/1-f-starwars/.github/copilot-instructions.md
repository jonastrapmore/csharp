# Copilot Instructions for F-STARWARS

## Project Overview
**F-STARWARS** is a C# console application for managing a list of Jedi Masters. The program runs a persistent menu-driven loop supporting CRUD operations: View, Add, Delete, and Edit Jedi entries.

## Architecture

### Core Pattern
- **Main Loop**: Menu-driven console application with switch statement routing (see [Program.cs](consoleapp/Program.cs#L13-L27))
- **Data Model**: Simple `List<string>` storing Jedi names (no persistence currently)
- **Validation Stack**: Hierarchical input validators ensure type safety and range constraints:
  - `LeesStringNietLeeg()` → validates non-empty strings
  - `LeesGetal()` → wraps string reader for numeric parsing
  - `LeesGetalMinMax()` → chains `LeesGetal()` with range bounds

### Key Implementation Details
- **Dutch terminology**: All method names and prompts use Dutch (Jedi = "Jedi", Add = "Toevoegen"). Maintain this convention.
- **No database**: Data is in-memory only; data is lost on exit (see Opdracht.md for constraints)
- **Menu indexing**: Menu is 1-indexed for user display; convert to 0-indexed internally if needed
- **Required methods** (per Opdracht.md):
  - `KeuzeMenu(string[])` - displays menu and returns validated choice
  - `LeesStringNietLeeg()`, `LeesGetal()`, `LeesGetalMinMax()` - validation chain
  - `PrintJedi(List<string>)` - displays Jedi list or "Er zijn geen Jedi!" if empty

## Developer Workflows

### Build & Run
```bash
dotnet build
dotnet run --project consoleapp/consoleapp.csproj
```

### Project Configuration
- **Target Framework**: .NET 8.0
- **Features**: Implicit usings enabled, nullable reference types enabled
- **Global Usings**: `System.Globalization` (see [GlobalUsings.cs](consoleapp/GlobalUsings.cs))

## Critical Requirements from Opdracht.md

### Menu Options
1. **Afsluiten** (Exit) - Case 1: exits loop
2. **Jedi Bekijken** (View) - Case 2: calls `PrintJedi()`
3. **Jedi Toevoegen** (Add) - Case 3: check for duplicates before adding
4. **Jedi Verwijderen** (Delete) - Case 4: validate Jedi exists before removing
5. **Jedi Editeren** (Edit) - Case 5: replace old name with new name and display result

### Validation Rules
- **Add operation**: Reject if Jedi already exists; confirm with "Jedi 'X' toegevoegd!"
- **Delete operation**: Reject if Jedi doesn't exist; confirm with "Jedi 'X' is verwijderd!"
- **Empty list handling**: Print "Er zijn geen Jedi!" when no entries exist
- **Menu range**: Always use `LeesGetalMinMax()` to enforce 1 to menu.Length bounds

## Code Style & Patterns
- Declare menu as string array at top of main logic
- Use local methods (see Program.cs structure) or top-level statements
- Case-insensitive Jedi name matching is NOT specified; assume case-sensitive unless told otherwise
- Use `new List<string>()` syntax (implicit typing preferred with implicit usings)
- Comments in Dutch match specification examples

## Common Pitfalls
- Forgetting to check for duplicate Jedi before adding
- Not using the validation method chain (e.g., calling `LeesGetal()` without `LeesGetalMinMax()`)
- Printing Jedi list before checking if empty
- Case sensitivity in Jedi name comparisons
