- [EscapeForest](#escapeforest)
  - [Important Contacts](#important-contacts)
  - [Code Guidelines and Commenting](#code-guidelines-and-commenting)
  - [Gitflow](#gitflow)
    - [Commit guidelines](#commit-guidelines)
    - [Features](#features)
    - [Hotfixes](#hotfixes)
    - [Releases](#releases)

# EscapeForest

CSDS390 Semester Long Project Escape from the Magic Forest

## Important Contacts

**Ally** Project Coordinator
**Reed** Programming Lead
**Cameron** Git handler

## Code Guidelines and Commenting

Use the same coding guideline as EECS132. To those who might not remember the guidelines here they are:
- All variables (fields, parameters, local variables) must be given appropriate and descriptive names.
- All variable and method names must start with a lowercase letter. All class and interface names must start with an uppercase letter.
- The class body should be organized so that all the fields are at the top of the file, the constructors are next, the non-static methods next, and the static methods at the bottom.
- There should not be two statements on the same line.
- All code must be properly indented (see page 644 of the Lewis book for an example of good style). The amount of indentation is up to you, but it should be at least 2 spaces, and it must be used consistently throughout the code.
- You must be consistent in your use of {, }. The closing } must be on its own line and indented the same amount as the line containing the opening {.
- There must be an empty line between each method.
- There must be a space separating each operator from its operands as well as a space after each comma.
- There must be a comment at the top of the file that is in proper JavaDoc format and includes both your name and a description of what the class represents. The comment should include tags for the author.
- There must be a comment directly above each method (including constructors) that is in proper JavaDoc format and states what task the method is doing, not how it is doing it. The comment should include tags for any parameters, return values and exceptions, and the tags should include appropriate comments that indicate the purpose of the inputs, the value returned, and the meaning of the exceptions.
- There must be a comment directly above each field that, in one line, states what the field is storing.
- There must be a comment either above or to the right of each non-field variable indicating what the variable is storing. Any comments placed to the right should be aligned so they start on the same column.
- There must be a comment above each loop that indicates the purpose of the loop. Ideally, the comment would consist of any preconditions (if they exist) and the subgoal for the loop iteration.
- Any code that is complicated should have a short comment either above it or aligned to the right that explains the logic of the code.


## Gitflow

[cheat sheet link](https://danielkummer.github.io/git-flow-cheatsheet/)

### Commit guidelines

- The name of the commit should be short and descriptive so that everyone can understand what happened without reading the description.
- Commits should be atomic. Basically avoid big commits of more than one element at a time. The more commits the better.
- Branch as much as you want inside your own feature. If you are doing a subfeature (ie coding the element of wind) branch and seperate it from the rest while you work on it.

### Features

Features will follow the following branching pattern: `feature/[NameOfTheFeature]`.

These will be merged inside of the `develop` branch once they are done. If you need to branch at any point, branch either from your feature branch or from the develop branch.

### Hotfixes

These should be done whenever we encouter a bug in any branch that is supposed to be done. They will follow a similar naming pattern `hotfix/[NameOfTheHotfix]`

### Releases

For this class I don't think we will use them but rather treat the `master` branch as the `release` branch. As such we need to keep it as clean as possible