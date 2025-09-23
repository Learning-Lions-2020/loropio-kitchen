# Contributing to Loropio Kitchen

We're excited that you want to contribute to Loropio Kitchen! This guide will help you get started.

## Branching Strategy

We follow a GitFlow-based branching model to manage our development process. The main branches are:

- **main:** This branch contains production-ready code. All commits to `main` are tagged for a new release.
- **develop:** This is the primary development branch where all feature and bugfix branches are merged. It represents the latest development version of the application.
- **feature/`feature-name`:** For new features. Branched from `develop` and merged back into `develop`.
- **bugfix/`bug-name`:** For fixing bugs. Branched from `develop` and merged back into `develop`.
- **release/`version-number`:** For preparing a new production release. Branched from `develop`. Release branches are used for final testing and bug fixing before merging into `main` and `develop`.

### Branch Protection

To ensure the stability of our codebase, the following branch protection rules are in place:

- **main:** Requires a pull request review before merging. Commits are not allowed directly.
- **develop:** Requires a pull request review before merging.

## Pull Requests

- All changes must be submitted via a pull request (PR).
- A PR must be reviewed and approved by at least one other developer before it can be merged.
- Your PR should include a clear description of the changes you've made.
- All PRs to `develop` must pass all status checks (e.g., build, tests, linting).

## Commit Messages

We follow the [Conventional Commits](https://www.conventionalcommits.org/en/v1.0.0/) specification. This helps us automate changelog generation and makes the commit history easier to read.

Each commit message should be in the format:

```
<type>[optional scope]: <description>

[optional body]

[optional footer]
```

- **type:** `feat`, `fix`, `docs`, `style`, `refactor`, `test`, `chore`, etc.
- **scope:** The part of the codebase the commit changes (e.g., `api`, `frontend`, `auth`).

**Example:**

```
feat(api): add endpoint for user wallet management
```

## Deployment

We use a multi-environment deployment strategy:

- **Development (`dev`):** Deployed automatically from the `develop` branch.
- **Staging (`staging`):** Deployed from `release` branches for final testing.
- **Production (`main`):** Deployed from the `main` branch after a new release is tagged.
