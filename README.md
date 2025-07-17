# LiveSplit.StandardDeviation
Standard deviation calculations for LiveSplit. A simple information tool that does a few things: 

Current Std Dev - displays the Standard Deviation information for the current split, reading your split file and displaying that information. Useful for assessing the viability of timesave (or loss) on this split. 

Previous Std Dev - displays the Standard Deviation information for the previous split, reading your live run and assessing it against historical performance. Useful for evaluating how "fun" RNG has been on this particular run. 

You can enable either or both!

There are some additional extra options for each:
- Sigma comparison; how many standard deviations is the current/previous split away from average. Useful for contextualising things.
- Average; what is the average for the current/previous split
- n=?; how many data points are being used
- Choose between seconds display and h:mm:ss format, with various rounding options

To use the component just copy the .dll file into the /Components directory of your LiveSplit folder. Everything in the VS Files is not required for using the component. The VS Files are raw Visual Studio code files for others to modify if they want to.

For the calculation the next version will include a limit to last N data points, but currently the calculation is over all datapoints in the current .lss file. 
