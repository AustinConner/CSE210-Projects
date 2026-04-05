# Relationship Manager

Relationship Manager is a personal CRM for people who want to stay connected with others. Track birthdays, employers, hobbies, and family ties - then log notes and interactions so you never forget the details that matter.

## Running the Program
### With VS Code
Easist way to run it without much setup is inside of VS Code. Ensure you have the [C# Dev Kit installed](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit) as well as the DOT.NET framework for your device. Once that's installed, you can run open `Program.cs` (or any class really) and press the "Play" button on the top right of the VS Code Window.

### Pre-Compiled EXE
There is a release on GitHub with the EXE file that you can download and run.
I created the release with the following command:
```
dotnet publish -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true
```
And published it as a release on GitHub. This is the easiest way to use the program without any installs (on Windows). Everything you need is bundled into one single file - ready to go!

[Download Relationship Manager v1.0 Here.](https://github.com/AustinConner/CSE210-Projects/releases/tag/RMv1.0)

## How to Use

### Main Menu
- **View People** — browse your list of people
- **Add Person** — create a new person
- **Remove Person** — delete someone from your list of people
- **Save** — save all data to disk (if running the exe, it'll be in the save folder it's running from.)
- **Load** — load previously saved data
- **Quit** — exit the program

> Save and load manually. Your data will not persist between sessions unless you save.

### Adding a Person
You will be prompted for:
- Name and relationship type (Acquaintance, Friend, Partner, Co-Worker)
- Optional: birthday, favorite color, hobbies, employer, partner, children, parents

> You won't be prompted with the questions that seek to link the person your making with someone else in the database if the person you're creating IS the first person in the program. There must be other people for you to link to.

### Person Details
Select a person to view their details and you'll see these options:
- **Add a note** — log a gift idea, interest, life event, or custom note
- **View notes** — see and delete existing notes
- **Log interaction** — record an in-person meeting, video call, or text conversation
- **View interactions** — see the history of interactions with that person
- **Edit person** — update any of their details

### Note Types
When creating a note, there's a few different note types you can pick from:
- Gift Idea
- Interest
- Life Event
- Custom

Each ask similar questions, but will have different "tags" listed on the "View notes" view to help you find those notes associated with someone.

### Interaction Types
As with notes, interactions have a few diffenet types you can pick from:
- In-Person
- Video Call
- Text

Each ask similar questions, but will have different "tags" listed on the "View Interactions" view to help you find those interactons associated with someone. It might be a good idea to reach out to someone you haven't logged an interaction with for a bit!

## Data Storage
### Running released EXE
Data is saved to *data.txt* in the same directory as the executable

### Running from VS Code
Data is saved to *data.txt* inside: `Project Folder > bin > Debug > net10.0 > data.txt`

> [!WARNING]
> Do not alter the content in the data.txt file after saving. You run the risk of it not loading back into the program. It might be wise to make periodic backups of this document to ensure you don't lose any data.