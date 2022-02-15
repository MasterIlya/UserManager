CREATE TABLE [dbo].[Messages]
(
	[MessageId] INT CONSTRAINT PK_Messages_MessageId PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[SenderId] INT NOT NULL,
	[RecipientId] INT NOT NULL,
	[MessageTopic] NVARCHAR(50) NOT NULL,
	[MessageText] NVARCHAR(1000) NOT NULL

	CONSTRAINT FK_Messages_Users_Sender FOREIGN KEY (SenderId) REFERENCES Users (UserId)
	CONSTRAINT FK_Messages_Users_Recipient FOREIGN KEY (RecipientId) REFERENCES Users (UserId)
)
