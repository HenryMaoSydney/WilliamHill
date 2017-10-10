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
assumption: if customer have no settled bet, it is unsusal ( average bet is 0).
Unsettled.csv seems not conaining wining/or not information, if we use ToWin as wining. this causes customer with unsettled bets be flagged as risky.
 
 
 Step 3 - The UI

 Using web API.
 Allow user 
 1) Query Customer's Risk Profile ( By Customer id)
 2) Query Bet's Risk Profile ( By Bet id)