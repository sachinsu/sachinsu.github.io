echo off
set arg1=%1

git add -A 
git commit -m %arg1%

git push origin source