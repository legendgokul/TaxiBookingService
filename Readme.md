popular zoho interview question to create a taxi booking service.

Question : 
- There are n number of taxi’s. For simplicity, assume 4. But it should work for any number of taxi’s.
- The are 6 points(A,B,C,D,E,F)
- All the points are in a straight line, and each point is 15kms away from the adjacent points.
- It takes 60 mins to travel from one point to another
- Each taxi charges Rs.100 minimum for the first 5 kilometers and Rs.10 for the subsequent kilometers.
- For simplicity, time can be entered as absolute time. Eg: 9hrs, 15hrs etc.
- All taxi’s are initially stationed at A.
- When a customer books a Taxi, a free taxi at that point is allocated
- If no free taxi is available at that point, a free taxi at the nearest point is allocated.
- If two taxi’s are free at the same point, one with lower earning is allocated
- Note that the taxi only charges the customer from the pickup point to the drop point. Not the distance it travels from an adjacent point to pickup the customer.
- If no taxi is free at that time, booking is rejected
