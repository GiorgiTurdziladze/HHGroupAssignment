First of all in appsettings.json I added Convertor configs for Taxes, Margin and Extra Margins.
With help of it Service folder, there is Calculate function to calculate if the "JOB" has extra margin or not, what is the cost of it, is it exempt or not
and after all the calculations, with CalculateJobTotal Endpoint, we can see the result.
In Startup.cs class Swager method is implemented and it is possible to test with passing JSON how it is working. Besides this, there is MSTestes added to the project
and with the running the tests, we can see how it working.

Here are examples of input data and output data for references

Job 1:
extra-margin
envelopes 520.00
letterhead 1983.37 exempt

should output:
envelopes: $556.40
letterhead: $1983.37
total: $2940.30

Job 2:
t-shirts 294.04

output:
t-shirts: $314.62
total: $346.96

Job 3:
extra-margin
frisbees 19385.38 exempt
yo-yos 1829 exempt

output:
frisbees: $19385.38
yo-yos: $1829.00
total: $24608.68

