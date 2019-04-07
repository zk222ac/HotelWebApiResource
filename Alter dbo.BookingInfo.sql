USE [HotelBookingDb]
GO

/****** Object: View [dbo].[BookingInfo] Script Date: 4/7/2019 5:38:11 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


ALTER VIEW BookingInfo AS 
SELECT b.BookingId AS BookingId, h.Name AS HotelName , r.Types AS RoomType, r.Price AS RoomPrice, 
g.Name AS GuestName , b.DateFrom AS DateFrom , b.DateTo AS DateTo , b.RoomNo AS RoomNo
FROM dbo.Hotel h , dbo.Room r , dbo.Guest g , dbo.Booking b
WHERE 
    h.HotelNo = r.HotelNo AND 
	r.HotelNo = b.HotelNo AND 
	b.RoomNo = r.RoomNo AND
	b.GuestNo = g.GuestNo;
