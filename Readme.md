# VBProject1: Digital Library with MongoDB

## How to Run the Project

1. **Prerequisites**

   - Install [.NET SDK](https://dotnet.microsoft.com/download) (minimum version 6.0).
   - Install MongoDB and start it on the default port (27017).
   - Clone the repository from your GitHub account:
     ```bash
     git clone <repository-url>
     cd VBProject1_LibreriaDigitale_MongoDB
     ```

2. **Running the Project**

   - Open the terminal in the project's root directory.
   - Build and run the project using the automation script:
     ```bash
     powershell -ExecutionPolicy Bypass -File buildAndRun.ps1
     ```
   - Once started, the GUI application will open, allowing interaction with the digital library.

3. **Note on Code Runner**

   - Code Runner is configured to automatically execute the `buildAndRun.ps1` script whenever code changes are made.
   - If using an editor other than Visual Studio Code, ensure to manually execute the build and run commands.

---

## Development and Changes Made

1. **Transition from Visual Basic to VB .NET**

   - To interact seamlessly with MongoDB, the project was migrated from "classic" Visual Basic to VB .NET, leveraging the .NET framework's compatibility with the MongoDB driver.

2. **Integration with MongoDB**

   - Added the `MongoDB.Driver` and `MongoDB.Bson` packages.
   - Implemented a `BookRepository` class to manage database operations, such as inserting, removing, and retrieving books.

3. **Build and Run Automation**

   - Created the `buildAndRun.ps1` script to automate build (`dotnet build`) and execution (`dotnet run`) commands.
   - Configured Code Runner to use this script instead of the default command.

4. **Code Optimizations**

   - Added the use of `Builders.Filter` to ensure MongoDB queries are compatible with the .NET driver.
   - Simplified logic in functions for removing and searching books in the GUI.

---

## Project Structure

```
VBProject1_LibreriaDigitale_MongoDB
|-- Models
|   |-- Book.vb               # Data model representing a book
|   |-- BookRepository.vb     # Class to interact with the MongoDB database
|
|-- Controllers
|   |-- BookController.vb     # Handles application logic between GUI and repository
|
|-- View
|   |-- GUIForm.vb            # Main graphical user interface of the application
|   |-- InputForm.vb          # Module to add new books
|   |-- OtherOptionsForm.vb   # Other app functionalities
|
|-- bin/                      # Compiled files (ignored in .gitignore)
|-- obj/                      # Temporary build files (ignored in .gitignore)
|-- buildAndRun.ps1           # Script for build and execution
|-- VBProject1_LibreriaDigitale_MongoDB.vbproj  # .NET project file
```

### Main Features

- **Digital Library**: Allows adding, removing, and viewing books with details such as title and year.
- **MongoDB Integration**: Persistent data storage using a NoSQL database.
- **Graphical User Interface**: Managed with Windows Forms for easy user interaction.
- **Automation**: PowerShell script for quick build and execution.

---

## Contributions

### Author

- **Name**: Giovanni Tassi
- **Role**: Developer

### Technologies and Tools Used

- **Language**: Visual Basic .NET
- **Database**: MongoDB
- **Framework**: .NET
- **Libraries**:
  - `MongoDB.Driver`
  - `MongoDB.Bson`
- **Editor**: Visual Studio Code
- **Automation**: PowerShell (buildAndRun.ps1)
- **Version Control**: Git and GitHub

---

For any questions or contributions, feel free to open an issue or create a pull request on the GitHub repository!



## Contributing

Pull requests are welcome. For major changes, please open an issue first
to discuss what you would like to change.

Please make sure to update tests as appropriate.