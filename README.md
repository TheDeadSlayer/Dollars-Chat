# Dollars-Chat
A desktop chat application made to resemble the chat client in the famous show Durarara!!.
Users infromation is saved on SQL database.

There are 3 main tiers:
- Dollar: Free basic tier, Requires code to sign up
- Premium: Has different avatars and colors, Requires Card info to sign up
- Admin: Gives adminstrator priveliges, Requires unique Admin code to sign up

Multiple clients can connect at the same time to the server using a simple TCP connection.

From the server side:
- All message history of current session can be viewed
- Users can be kicked or banned from room
- View connected clinets and their IP
- Access main SQL database

Their is a seceret hidden easteregg ;)
