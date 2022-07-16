Large files are excluded via the following command

```
forfiles /s /c "cmd /q /c if @fsize GTR 100000000 echo @relpath" >> .gitignore
```