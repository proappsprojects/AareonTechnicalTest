Title: Aareon Ticketing System

Description: Implemented RESTful API to Create, Read, Update, and Delete (CRUD) tickets.

Work-in-progress:

I managed to implement RESTful api to Create, Read, Update and Delete operations. Added automated tests for Create and Read actions under project AareonTechnicalTest.Tests. Services are Data folder is under the same solution. In a real-time project, I would put them in a separate project.

Work-in-progress/Work not completed:

1. Services and Database layers should go into a separate project of their own.
2. Unit tests are not created/added for the service layer.
3. No exception logging was added to the project. Setting up ELMAH or a similar tool will help store errors in a central location
4. I didn’t add the Notes field/column to a Ticket.
5. I didn’t add data manipulation and actions.
