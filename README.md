# MyBlog

## Create your blog in seconds using this template 

It will be hosted using **GitHub Pages** (so  it's free) and it doesn't need any database. Also, **it's pure Microsoft Blazor code!!**

See it in action at my site [https://abbatepabloo.github.io/MyBlog](https://abbatepabloo.github.io/MyBlog)

## Steps

- Click on **Use this template** button
- Use **myblog** for the repository name. It's important to respect this value or the site won't work
- Click on **Create repository from template** button
- Edit the file MyBlog.Core/InformationProvider.cs and replace the constant Owner with your GitHub's user name. Mind is abbatepabloo. So if your is **smithjohn** you would end up with the following line:
```csharp
public const string Owner = "smithjohn";
```
- Commit the change in order to fire the **GitHub Action** responsible for the content's deployment

## Verify Git Hub Action has been triggered
This site uses **Git Hub Actions** to deploy the content into **Git Hub Pages**. In order to verify that this step has been executed successfully:
- Goto **Actions** option
- Verify you have at least one successfull action
- If you have errors:
  - Be sure you used the right repository name. If not, you can delete the repository and start all over again.
  - Also verify the value of **Owner** is correct. If not, re-edit the **InformationProvider.cs** file and commit the changes.

## Enable Git Hub Pages

- Goto **Settings** option
- Inside **Settings** select **Pages** option from side bar
- In the **Source** section select the banch **gh-pages** at the combobox
- Click on **Save** button




