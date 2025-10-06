# Contributing to Loropio Kitchen

We're excited that you want to contribute to Loropio Kitchen! This guide will help you get started.

## Branching Strategy

We use the **Git Releaseflow** branching model for simplicity and clarity. The main branches are:

- **main:** The single source of truth. All features, hotfixes, and releases are branched from and merged into `main` via pull requests.
- **feature/short-description:** For new features. Branched from `main` and merged back into `main` after review and testing.
- **hotfix/short-description:** For urgent bug fixes. Branched from `main` and merged back into `main` via pull request. If the bug affects a current release, also merge into the release branch.
- **release/sprint-XX:** Created from `main` at the end of each sprint (e.g., `release/sprint-29`). Deployed to production. Old release branches can be deleted to keep the repo clean.

### Branch Protection

To ensure the stability of our codebase, the following branch protection rules are in place:

- **main:** Requires a pull request review before merging. Commits are not allowed directly.

## Pull Requests

- All changes must be submitted via a pull request (PR).
- A PR must be reviewed and approved by at least one other developer before it can be merged.
- Your PR should include a clear description of the changes you've made.
- All PRs to `main` must pass all status checks (e.g., build, tests, linting).

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

- **Production:** Deploy from the latest release branch.
- **Other environments:** Use feature flags to control feature visibility.

For different environments (test, staging, production), use feature flags in your code rather than maintaining multiple release branches. This allows you to enable or disable features per environment.

For more details on our architecture, see the [Architecture Guide](./docs/ARCHITECTURE.md).
