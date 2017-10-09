# William Hill Coding Test


I am not going to build a complicated UI. The task seems suitable of one of macro services.

Step 1 - the reposiory
The application will load settle.csv and unsettle.csv into a local data repository.
the dtabase interface should support:
GetSettledBets(CustomerId)
GetUnsettledBets(CustomerId)
GetCustomers()

Step 2 - the risk profiler
Customer Risk Profile can be calculated by settled bet.
This also calculates Customer's average bet
 
Bet Risk Profiler is more complicated. It depend on 4 conditions 
The Risk characteristics are risky,  ( highly unusual /  unusual / Normal), Large sum. 

 
