# William Hill Coding Test


I am not going to build a complicated UI. The task seems suitable of one of macro services. I am using a webAPi as UI.

The Webapi entry point is:  
http://localhost:13926/CustomerRiskProfiler/1  
http://localhost:13926/DisplayAllUnsettledBetWithRisk


The coding process:

Step 1 - the reposiory
The application will load settle.csv and unsettle.csv into a local data repository.
the dtabase interface should support:
GetSettledBets(CustomerId)
GetUnsettledBets(CustomerId)
GetCustomers()

Step 2 - the risk profiler
Customer Risk Profile can be calculated by settled bet.
This also calculates Customer's average bet
 
Bet Risk Profiler is more complicated. It depend on the unsettled bet and the Customer risk profile
The Risk characteristics are risky,  ( highly unusual /  unusual / Normal), Large sum. 
  
Step 3 - The UI
 
 Allow user to query for Customer's risk profile, and Display All unsettled bet's risk status 

Step 4 - Fixes, Async, Parallel, Thread safe collections.
 
  