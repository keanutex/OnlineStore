--get it to the correct location and then drop the database if it already exists

USE master
IF EXISTS(select * from sys.databases where name='CoroNacessitiesDB')
DROP DATABASE CoroNacessitiesDB

--create database 
CREATE DATABASE CoroNacessitiesDB;
GO

USE CoroNacessitiesDB
GO

:SETVAR path ".\"


print '---------Created Database---------'

--create all the tables

:r $(path)\CreateAddressTable.sql
print 'created Address table'

:r $(path)\CreateProductTable.sql
print 'created Product table'

:r $(path)\CreateProductTypeTable.sql
print 'created ProductType table'

:r $(path)\CreateProductStatusTable.sql
print 'created ProductStatus table'

:r $(path)\CreateOrderStatusTable.sql
print 'created OrderStatus table'

:r $(path)\CreateOrdersTable.sql
print 'created Orders table'

:r $(path)\CreateCityTable.sql
print 'created City table'

:r $(path)\CreateOrderItemTable.sql
print 'created OrderItem table'

:r $(path)\CreateUsersTable.sql
print 'created Users table'

print '---------created all tables---------' 

:r $(path)\CreateUsersTable.sql

print 'created Users table'

print '---------created all tables---------' 

GO

:r $(path)/CreateLocationView.sql

print '---------Views created---------'

GO
:r $(path)/InsertDataScript.sql

print '---------Inserts Done---------'

GO
