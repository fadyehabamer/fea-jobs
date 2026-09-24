# FEA Jobs
> FEA Jobs is a basic recruitment online website developed using the following technologies:
1. ASP.NET Core MVC
2. Entity Framework Core
3. SQL Server


# Account
Below are the accounts used in the project with their respective roles: User, Employer, Admin

Email | Password | Role
-------- | -------- | --------
admin@gmail.com | Abc123!@# | Admin
techcombank@gmail.com | 123123 | Employer
dektechnologies@gmail.com | 123123 | Employer
orientsoftware@gmail.com | 123123 | Employer
user1@gmail.com | 123123 | User
... | 123123 | User
user10@gmail.com | 123123 | User

# Repository layout

Path | What it is
-------- | --------
`job_portal.sln` | Visual Studio solution with the three projects below
`JobPortal.WebApp/` | ASP.NET Core MVC site (net8.0): controllers, Razor views, `wwwroot` static files
`JobPortal.Data/` | Entity Framework Core model: entities, configurations, migrations, view models, seed data
`JobPortal.Common/` | Shared helpers (image upload/delete, text helpers, salary range validation)
`JobPortalDb.sql` | SQL Server script (UTF-16) that creates and fills the `JobPortalDb` database
`template/user/` | Original Colorlib "Job Listing" HTML template the public site is built from (reference only, not served)
`template/admin-employer/` | Original Sneat Bootstrap 5 admin template the Admin and Employer areas are built from (reference only, not served)

# Pages

**Public site** (`JobPortal.WebApp/Views`, layout `Views/Shared/_Layout.cshtml`)

Page | Route | View
-------- | -------- | --------
Home | `/` | `Home/Index`
Jobs list / detail | `/job`, `/job/{slug}` | `Job/Index`, `Job/Detail`
Search | `/search` | `Search/Index`
Companies list / detail | `/company`, `/company/{slug}` | `Company/Index`, `Company/Detail`
Blog list / post | `/blog`, `/blog/{slug}` | `Blog/Index`, `Blog/Detail`
Apply for a job, my applications | `/apply/...` | `Apply/Apply`, `Apply/ListApplies`
Register as / update employer | `/register-employer/...` | `Employer/Register`, `Employer/RegisterToEmployer`, `Employer/Update`
About, pricing, contact, elements, privacy | `/about-us`, `/price`, `/contact`, `/elements`, `/privacy` | `Home/*`
Sign in, register, change password | `/login`, `/register`, `/change-password` | `Account/*` (layout `_LayoutAccount`)

**Admin area** (`JobPortal.WebApp/Areas/Admin`, `/admin`): dashboard, users and roles, employer
approval, and CRUD for skills, job categories, titles and provinces.

**Employer area** (`JobPortal.WebApp/Areas/Employer`, `/employer`): dashboard, job posts,
blog posts, and reviewing/accepting/denying applications with feedback.

Uploaded files are stored under `JobPortal.WebApp/wwwroot/images/` (`employers`, `skills`,
`blogs`, `cvs`, `countries`, `default`) and are served from `/images/...`.

# Running locally

1. Run `JobPortalDb.sql` against a SQL Server instance (it creates `JobPortalDb`).
2. Point `ConnectionStrings:JobPortalContextConnection` in `JobPortal.WebApp/appsettings.json` at that server.
3. `dotnet run --project JobPortal.WebApp` and sign in with one of the accounts above.
