The classes contained under Identity namespace are used for managing application users.

That is created becasue EntityFramework provides a default implemention of UserManager. 
It containes implementations of typical user based actions so without the need to reinvent the wheel it was used.

The drawback of using it is that requires to maintain the specific entities which are tight coupled with EntityFramework.
To abstract those ORM specific enities simple mappings was created.