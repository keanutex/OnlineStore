--Product Table
ALTER TABLE [Product]
ADD
FOREIGN KEY ([UserID]) REFERENCES Users([UserID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

ALTER TABLE [Product]
ADD
FOREIGN KEY ([StatusID]) REFERENCES Status([StatusID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

ALTER TABLE [Product]
ADD
FOREIGN KEY ([TypeID]) REFERENCES ProductType([TypeID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

--Users Table
ALTER TABLE [Users]
ADD
FOREIGN KEY ([AddressID]) REFERENCES Address([AddressID]) ON DELETE NO ACTION ON UPDATE NO ACTION;