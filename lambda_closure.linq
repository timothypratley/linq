<Query Kind="Statements" />

Enumerable.Select(
	new [] {1, 2, 3},
	x => x + 1)
.Dump();



int a = 3;
Func<int, int> f = x => x + a;
f(2).Dump();
	
// what will happen?
a = 10;
f(2).Dump();




