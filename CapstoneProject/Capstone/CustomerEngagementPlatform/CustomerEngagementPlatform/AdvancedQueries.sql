USE CustomerEngagementDB;
GO

-- ==========================================
-- DELETED TICKET LOG TABLE
-- ==========================================

CREATE TABLE DeletedTicketsLog
(
    LogId INT IDENTITY(1,1) PRIMARY KEY,
    TicketId INT,
    Title NVARCHAR(200),
    DeletedDate DATETIME DEFAULT GETDATE()
);
GO

-- ==========================================
-- DELETE TRIGGER
-- ==========================================

CREATE TRIGGER trg_TicketDelete
ON Tickets
AFTER DELETE
AS
BEGIN
    INSERT INTO DeletedTicketsLog
    (
        TicketId,
        Title
    )
    SELECT
        TicketId,
        Title
    FROM deleted;
END;
GO

-- ==========================================
-- JOIN QUERY
-- ==========================================

SELECT
    c.CustomerId,
    c.Name,
    c.Email,
    t.TicketId,
    t.Title,
    t.Status
FROM Customers c
INNER JOIN Tickets t
ON c.CustomerId = t.CustomerId;
GO

-- ==========================================
-- TRIGGER TEST EXAMPLE
-- ==========================================

-- DELETE FROM Tickets
-- WHERE TicketId = 2;

-- SELECT * FROM DeletedTicketsLog;