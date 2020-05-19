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

:r $(path)\CreateStatusTable.sql

print 'created Status table'

:r $(path)\CreateUsersTable.sql

print 'created Users table'

print '---------created all tables---------' 

GO


--add the foreign keys

:r $(path)/CreateForeignKeys.sql

print 'created foreign keys for Users table and Product table'

print '---------created all foreign keys---------'

GO
