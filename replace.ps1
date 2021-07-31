(Get-Content MyBlog/wwwroot/index.html).replace('href="/"', 'href="/MyBlog/')| 
Set-Content MyBlog/wwwroot/index.modif