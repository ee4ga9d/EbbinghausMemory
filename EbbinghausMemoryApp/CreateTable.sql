CREATE TABLE IF NOT EXISTS Users (Id INTEGER PRIMARY KEY AUTOINCREMENT,UserNo TEXT NOT NULL UNIQUE)
;

CREATE TABLE IF NOT EXISTS BookItems (Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                                     Content TEXT NOT NULL,
                                                     CategoryId INTEGER,
                                                     FOREIGN KEY (CategoryId) REFERENCES Categories (Id))
;
CREATE TABLE IF NOT EXISTS Categories (Id INTEGER PRIMARY KEY AUTOINCREMENT, Name TEXT NOT NULL)
;
CREATE TABLE IF NOT EXISTS StudyItems (Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                                     Content TEXT NOT NULL,
                                                     BookId INTEGER,
													 User_Id  INTEGER,
													 Experience Text,
                                                     FOREIGN KEY (BookId) REFERENCES BookItems (Id))
;
CREATE TABLE IF NOT EXISTS ReviewTimes (Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                                    StudyItemId INTEGER,
                                                    ReviewDateTime TEXT,
                                                    Reviewed BOOLEAN,
													Experience Text,
                                                    FOREIGN KEY (StudyItemId) REFERENCES StudyItems (Id))
;