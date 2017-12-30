# ABOUT KP LOG ANALYZER
There are several log reader tools, e.g. Log Expert, TailBlazer, Vim, Notepad++, etc. So why do I have to write this KP Log Analyzer? - Well, the reason is simple: they failed to serve our team's daily needs by consuming too much of our support time.

Let me further describe our scenario:

We are the support team of a system consisting of several applications deployed in different load-balanced servers. Each client request will go through a web application in one of the load-balanced web servers, then through at least 1 service in one of the load-balanced app servers. Depending on the importance of the data and the role of the serving application in the whole processing flow, a log can be recorded by a webapp or service or both (i.e. logs are scattered across servers). Because we have thousands of customers/users, it is normal to have millions of requests per day. As a result, our daily logs are totally about a few GBs. Although we have configured the log writer tool to split logs into files based on categories and dates, we still have log files up to 2 GBs.

Each log item is formatted like this:

        [Some timestamp] Some description
        Details
        spreading
        several
        lines
        ...
    
Typically, the description or details will contain data to identify the relevant customer. So, when a customer has an issue, our main task is to ask for his customerId plus some issue-specific details and search for the relevant logs.

Using an available log tool reveals these drawbacks:

- Such tools are based on lines, while each of our log items often consists of multiple lines. As a result, the tools can filter lines matching some criteria, but cannot extract the containing log items for us.
- They process one file at a time, while we have several files to process. Even the time to specify all those files is long enough.
- Not all of them support regular expressions.
- They do not allow 2-level filtering, e.g. we need to filter logs from a group of logs of a specific customer.
- They do not allow partial analysis for faster performance, e.g. we know for sure that the logs we need do not exist in the first million lines, so we want to start our filtering from the 1000001-th line.
- Most of them provide a view of the original file. However, in some tools that view just hangs up or cannot be opened for files larger than 500 MBs. And for us, that view is unnecessary in most cases. We often had just enough time to focus on certain items, rather than everything.
... and the drawbacks daily cost us a lot of time until we developed Log Analyzer :).

So, as you can guess, basic features of Log Analyzer will be:
- Be based on lines and log items. The specified criteria will be matched against lines, but the result items will be log items. A log item will be identified based on starting lines. You can define how the starting line of an item looks like, using a regular expression or a StartsWith keyword. A log item is considered to span from 1 starting line to right before the next starting line (if any) or to the end of the file.
- Support batch analysis. You can specify a folder and a file mask. All matching files will be processed in one click, and the results are still separated by file.
- Support regular expressions. All search criteria can be specified in regex or not, inclusively or exclusively, which means you have maximal flexibility.
- Support 2-level filtering. After having analyzed the logs, you can perform quick filtering on the results. Again, regex is possible.
- Support partial analysis for faster performance. You can specify which line to start analysis as well as the number of first results we need. This is very useful if you need to progressively analyze log files that get bigger and bigger over time.
- Support NO view of the original file.

Besides, there are a few more useful advanced features. For example, you can:
- Choose the display font for Grid and Details Views.
- Copy selected items to clipboard
- Help is not available for all UI elements. But if there is, you can hover to see the help. For example, you can try hovering the Exclusive checkboxes to know what they are meant for.

I know there can be many cool features to add, but that is a good-enough start. Try it :)!

# SYSTEM REQUIREMENTS
To work with the code, you need 
- Visual Studio 2010 or later
- .NET Framework 4.0
To run the release (e.g. the one here https://github.com/PhuongNQK/releases/blob/master/KP-Log-Analyzer-1.0.zip), you need
- .NET Framework 4.0 Client Profile

Enjoy :)!
