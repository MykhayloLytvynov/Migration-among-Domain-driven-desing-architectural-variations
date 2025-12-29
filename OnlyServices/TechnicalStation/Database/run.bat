SET PATH=%PATH%;"C:\Program Files\MySQL\MySQL Server 8.0\bin"
mysql -u root -ppassword < "createdb.sql" > 1.txt
mysql -u root -ppassword < "customer.sql" > 1.txt
mysql -u root -ppassword < "car.sql" > 1.txt
mysql -u root -ppassword < "worker.sql" > 2.txt
mysql -u root -ppassword < "work.sql" > 2.txt
mysql -u root -ppassword < "order.sql" > 2.txt

echo mysql -u root -ppassword < "user.test.set.sql" > 1.txt

echo mysql -u root -ppassword < "member.query.sql" > 1.txt
