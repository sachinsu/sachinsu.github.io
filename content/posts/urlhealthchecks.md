---
title: "Validating urls from 'Useful Links' section using bash / command line tools"
date: 2020-10-15T10:25:04+05:30
draft: false
tags: [bash, grep, sed, curl]
---

## Background

I started this blog, [https://sachinsu.github.io](https://sachinsu.github.io) few months back .

In this relatively short period of time, Blog has sizeable number of useful links across various categories in addition to the detailed blog post like this one.

As an ongoing activity, I think that it is necessary to verify links mentioned on this blog.

So how can it be done ? obviously one way is to do it manually by visiting each link and updating/removing those that are no longer available. but there is always of better way of doing things.

The requirement is to,

- Parse all the files to links (being in Markdown links will be enclosed in brackets)
- Send request to each link and verify if its active using HTTP Status (say 200 or 302)

## Approach

Enter Automation !!

It is possible to write a utility/tool (or it might be already available) or can good old command line utlities be used for this task?

I decided to go for dos / shell script way and surprisingly all the necessary tools are already available.

Below is single command line that fulfils the requirement, 

`grep -E -i -w "http|https" *.md | sed 's/](http/\nhttp/g' | sed 's/)/\n/g' | grep ^http | xargs curl -s -I  -w 'URL:%{url_effective} - %{http_code}\n' | grep ^URL:`

In above chain, 

- I am using excellent [Cmder](https://cmder.net/) console emulator, which also makes above nice tools (grep, sed etc.) available on Windows.

- [grep](https://man7.org/linux/man-pages/man1/grep.1.html) -E -i -w "http|https" *.md  - this command extracts all the lines containing `http(s)` from all the markdown (.md) files 

- [Pipe |](https://en.wikipedia.org/wiki/Pipeline_(Unix)) - Pipe command streams output of command to the next one.

- [sed](https://en.wikipedia.org/wiki/Sed) 's/](http/\nhttp/g' - this sed (stream editor) command adds line break before `http` for better extraction.

- [sed](https://en.wikipedia.org/wiki/Sed) 's/)/\n/g' - this sed (stream editor) command removes trailing `)` bracket.

- [grep](https://man7.org/linux/man-pages/man1/grep.1.html) ^http  - this command removes all lines not containing `http`.

- [xargs](https://man7.org/linux/man-pages/man1/xargs.1.html) - xargs is a command on Unix and most Unix-like operating systems used to build and execute commands from standard input.

- [curl](https://curl.haxx.se/) -s -I  -w 'URL:%{url_effective} ---> %{http_code}'' - previously used `xargs` command feeds each line (url) to this command as last argument. This command sends tcp request to the URL and prints out http status code along with URL. 

- [grep](https://man7.org/linux/man-pages/man1/grep.1.html) ^URL: - For some reason, CURL outputs content even if `-s` (silent) parameter is passed. Hence, this grep command is used to ignore all lines not containing URL and HTTP Status.

The output is as below, 

{{< figure src="/images/urloutput.png" title="List of URLs with HTTP Status code" >}}


So, It is  possible to quickly come up with this using built-in tools if writing a program is not an option or cumbersome for task at hand.

As a next step, Plan is to automatically run this script as part of Github Build and notify in case of any URL is failing so that appropriate action can be taken.

### Hat Tip
Suppose the requirement is to extract a particular text by recursively searching through files(for e.g. extract Target .NET Framework version across each of the project in a folder) then grep can be used as below, 

` grep -r --include "*.csproj"  -oP "<TargetFrameworkVersion(?:\s[^>]*)?>\K.*?(?=</TargetFrameworkVersion>)" . `

This command will recursively search through all folders and print names of all those `.csproj` files containg `<TargetFrameworkVersion>` tag. 

Let me know (in comments) if you are aware of any alternate better way of achieving this.

Happy Coding !!

---

{{< comments >}}