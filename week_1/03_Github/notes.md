
## 1. Version Control Concepts

### What is Version Control?

Version control is a system that tracks changes made to files over time. It allows developers to:

- Track who made changes and when.
- Restore previous versions of code.
- Work on different features simultaneously.
- Collaborate without overwriting each other's work.
- Identify and resolve conflicts.

### What is Git?

Git is a distributed version control system (DVCS) used to track changes in source code.

Every developer has a complete copy of the repository and its history on their local machine.

### Important Terms

| Term              | Meaning                                              |
| ----------------- | ---------------------------------------------------- |
| Repository (Repo) | A project folder tracked by Git.                     |
| Working Directory | Files you are currently editing.                     |
| Staging Area      | Area where changes are prepared before committing.   |
| Commit            | A saved snapshot of staged changes.                  |
| History           | Record of previous commits.                          |
| Branch            | Independent line of development.                     |
| Merge             | Combining changes from different branches.           |
| Remote            | A repository hosted elsewhere, such as GitHub.       |
| HEAD              | Pointer to the current commit or checked-out branch. |

### Why do teams use Git?

1. Multiple developers can work on the same project.
2. Changes can be tracked and reviewed.
3. Previous versions can be restored.
4. Different features can be developed independently.
5. Conflicts can be identified and resolved.
6. Code collaboration becomes easier.

### Git vs GitHub

| Git                  | GitHub                                |
| -------------------- | ------------------------------------- |
| Version control tool | Cloud-based hosting platform          |
| Works locally        | Provides online repositories          |
| Tracks code changes  | Enables collaboration                 |
| Command-line tool    | Web interface and collaboration tools |

Remember: Git is the tool; GitHub is a platform that hosts Git repositories.

## 2. Everyday Git Commands

### Initialize a repository – `git init`

Creates a new Git repository in the current directory.

```
git init
```

Creates a hidden `.git` folder containing repository information.

### Clone a repository – `git clone`

Downloads an existing remote repository to your local machine.

```
git clone https://github.com/user/project.git
```

### Check repository status – `git status`

Displays the current state of files.

```
git status
```

It tells you about:

- Untracked files.
- Modified files.
- Staged changes.
- Current branch.

### Add changes – `git add`

Moves changes from the working directory to the staging area.

```
git add file.cs
```

Stage all changes:

```
git add .
```

### Commit changes – `git commit`

Saves staged changes as a commit.

```
git commit -m "Add login functionality"
```

A commit usually contains:

- Unique commit ID (hash).
- Author information.
- Timestamp.
- Commit message.
- Snapshot of the project.

### View commit history – `git log`

Displays previous commits.

```
git log
```

Compact history:

```
git log --oneline
```

### View differences – `git diff`

Shows changes that have not yet been staged.

```
git diff
```

Compare staged changes:

```
git diff --staged
```

### Ignore files – `.gitignore`

A `.gitignore` file specifies files and folders Git should ignore when identifying untracked files.

Example:

```
bin/
obj/
.env
*.log
node_modules/
```

Common uses:

- Build output.
- Temporary files.
- Environment variables and secrets.
- Dependency folders.

Important: `.gitignore` does not automatically stop tracking files that are already tracked by Git.

## 3. Branches

### What is a branch?

A branch is an independent line of development.

It allows developers to work on new features or bug fixes without directly modifying the main branch.

Common branch names:

- `main` – primary stable branch.
- `feature-login` – new feature.
- `bugfix-payment` – bug fix.
- `development` – ongoing development.

### Create a branch

```
git branch feature-login
```

### View branches

```
git branch
```

### Switch branches

```
git switch feature-login
```

Older command:

```
git checkout feature-login
```

### Create and switch to a new branch

```
git switch -c feature-login
```

### Merge branches

Merge changes from another branch into your current branch.

For example, to merge `feature-login` into `main`:

```
git switch main
git merge feature-login
```

Remember: You merge the specified branch into the branch you are currently on.

### Delete a branch

```
git branch -d feature-login
```

Force delete:

```
git branch -D feature-login
```

## 4. Merge Conflicts

### What is a merge conflict?

A merge conflict occurs when Git cannot automatically combine changes from different branches.

Example:

Both developers modify the same line in a file.

Git may display:

```
<<<<<<< HEAD
Console.WriteLine("Hello");
=======
Console.WriteLine("Welcome");
>>>>>>> feature-login
```

Meaning:

- `<<<<<<< HEAD` – changes from the current branch.
- `=======` – separates the two versions.
- `>>>>>>> feature-login` – changes from the incoming branch.

### How to resolve a merge conflict

1. Open the conflicting file.
2. Understand both changes.
3. Decide which changes to keep, or combine them.
4. Remove the conflict markers.
5. Save the file.
6. Stage the resolved file.
7. Complete the merge commit if required.

```
git add file.cs
git commit
```

Important: Git does not decide which developer's code is correct. Developers must resolve the conflict themselves.

## 5. Remote Repositories

### What is a remote?

A remote is a reference to a repository hosted somewhere else, usually GitHub, GitLab, or Bitbucket.

### View configured remotes

```
git remote -v
```

### Add a remote

```
git remote add origin https://github.com/user/project.git
```

`origin` is the conventional default name for the primary remote.

### Push

Uploads local commits to a remote repository.

```
git push origin main
```

For the first push of a new branch:

```
git push -u origin feature-login
```

`-u` sets the upstream tracking branch, so future pushes can often use just `git push`.

### Pull

Downloads changes from the remote and integrates them into your current branch.

```
git pull origin main
```

By default, `git pull` performs a fetch followed by a merge (unless configured differently).

### Fetch

Downloads remote changes and updates remote-tracking references without merging them into your current branch.

```
git fetch origin
```

### Pull vs Fetch

| Git Pull                               | Git Fetch                       |
| -------------------------------------- | ------------------------------- |
| Downloads remote changes               | Downloads remote changes        |
| Integrates changes into current branch | Does not integrate changes      |
| Updates your working branch            | Leaves working branch unchanged |
| Fetch + merge by default               | Fetch only                      |

Easy way to remember:

- `fetch` = Download and inspect.
- `pull` = Download and integrate.
- `push` = Upload your commits.

## 6. Pull Requests (PRs)

### What is a Pull Request?

A Pull Request is a request to merge changes from one branch into another branch.

It is commonly used on GitHub, GitLab, and Bitbucket.

Example:

A developer creates a `feature-login` branch and wants to merge it into `main`.

They open a Pull Request.

### Pull Request Workflow

1\. Create a feature branch

git switch -c feature-login

2\. Make changes and commit

git add . → git commit

3\. Push the branch

git push origin feature-login

4\. Open a Pull Request

Request to merge feature-login into main

5\. Review and feedback

Reviewers comment and suggest changes

6\. Approve and merge

Changes integrated into main

### Important PR terms

| Term            | Meaning                                            |
| --------------- | -------------------------------------------------- |
| Open PR         | Request to merge code into another branch.         |
| Review          | Examine code for quality, correctness, and issues. |
| Comment         | Provide feedback on proposed changes.              |
| Approve         | Reviewer accepts the proposed changes.             |
| Request Changes | Reviewer asks for modifications before approval.   |
| Merge           | Integrate the PR changes into the target branch.   |

### Types of Merge

1\. Merge Commit

Combines branches and creates a merge commit, preserving branch history.

2\. Squash Merge

Combines all commits from a PR into one commit before merging.

Example:

Before squash:

```
Add login page
Fix login validation
Update login styling
```

After squash:

```
Add login functionality
```

3\. Rebase and Merge

Replays commits from one branch on top of another branch, creating a linear history without a merge commit.

## 7. Good Git Habits

### 1. Make small commits

Each commit should represent a small, meaningful change.

Bad:

```
git commit -m "Changes"
```

Good:

```
git commit -m "Add student validation"
```

### 2. Write meaningful commit messages

Commit messages should describe what changed.

Examples:

- `Add user authentication`
- `Fix payment validation`
- `Update database connection`

### 3. Pull before pushing

Before pushing your changes, synchronize with the latest remote changes to reduce integration problems.

```
git pull origin main
git push origin main
```

In team workflows, it is generally better to pull changes into your feature branch and push that branch rather than directly pushing to `main`.

### 4. Use branches

Avoid making all changes directly in the main branch.

### 5. Never commit secrets

Do not commit:

- API keys.
- Passwords.
- Database credentials.
- Private environment files.

Use `.gitignore` and environment variables.

### 6. Review changes before committing

```
git status
git diff
```

### 7. Keep your repository clean

Remove unnecessary files and use meaningful folder structures.

## 8. Most Important Commands – Quick Revision

| Command                     | Purpose                                     |
| --------------------------- | ------------------------------------------- |
| `git init`                  | Initialize repository                       |
| `git clone`                 | Copy remote repository locally              |
| `git status`                | Check file status                           |
| `git add .`                 | Stage all changes                           |
| `git commit -m "message"`   | Save staged changes                         |
| `git log`                   | View commit history                         |
| `git diff`                  | View unstaged changes                       |
| `git diff --staged`         | View staged changes                         |
| `git branch`                | List branches                               |
| `git branch name`           | Create branch                               |
| `git switch name`           | Switch branch                               |
| `git switch -c name`        | Create and switch branch                    |
| `git merge name`            | Merge specified branch                      |
| `git branch -d name`        | Delete branch                               |
| `git remote -v`             | View remotes                                |
| `git remote add origin URL` | Add remote                                  |
| `git push`                  | Upload commits                              |
| `git pull`                  | Download and integrate changes              |
| `git fetch`                 | Download remote updates without integration |

## 9. Important Gateway Exam Differences

| Concepts                  | Key difference                                           |
| ------------------------- | -------------------------------------------------------- |
| Git vs GitHub             | Version control tool vs hosting platform                 |
| `git init` vs `git clone` | Create local repository vs copy existing repository      |
| `git add` vs `git commit` | Stage changes vs save changes                            |
| `git diff` vs `git log`   | Show code differences vs show commit history             |
| Branch vs Repository      | Independent development line vs complete project history |
| Merge vs Rebase           | Combine branches vs replay commits                       |
| Pull vs Fetch             | Download and integrate vs download only                  |
| Push vs Pull              | Upload local commits vs download and integrate           |
| PR Review vs Approval     | Examine code vs accept proposed changes                  |
| Merge vs Squash Merge     | Preserve individual commits vs combine them into one     |

## 10. Common MCQ Traps

- `git add` does not create a commit.
- `git commit` saves only staged changes.
- `git fetch` does not automatically merge changes.
- `git pull` normally performs fetch + merge.
- `git push` uploads commits, not simply every modified file.
- A branch is not a separate repository.
- A Pull Request is not the same as `git pull`.
- `.gitignore` does not automatically untrack previously tracked files.
- A merge conflict requires manual resolution when Git cannot combine changes automatically.
- `origin` is a conventional remote name, not a mandatory name.
- Squash merge combines multiple commits into one.
- `HEAD` refers to the currently checked-out commit/branch.

