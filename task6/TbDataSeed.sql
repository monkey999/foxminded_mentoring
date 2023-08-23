USE University;
GO

INSERT INTO COURSES (COURSE_ID, COURSE_NAME, DESCRIPTION) VALUES
	(1, 'C#/.NET', 'This course will teach you how to create phishing software'), 
	(2, 'SQL', 'This course will teach you how to use sql injections'), 
	(3, 'Algorithms and Data Structures', 'This course will teach you how to brutforce passwords'), 
	(4, 'Networks', 'Learn cross-site scripting, port scanning, buffer overflow etc.'), 
	(5, 'OS architecture', 'Create your rootkit');

INSERT INTO GROUPS (GROUP_ID, COURSE_ID, GROUP_NAME) VALUES
    (1, 1, 'SR-01'),
    (2, 4, 'SR-02'),
    (3, 5, 'FR-01'),
    (4, 3, 'FR-02'),
    (5, 2, 'SR-01');

DECLARE @names TABLE (nameLocal VARCHAR(50));
DECLARE @surnames TABLE (surnameLocal VARCHAR(50));

INSERT INTO @names (nameLocal) VALUES 
('John'), ('Sarah'), ('David'), ('Emily'), ('Michael'), ('Olivia'), ('William'), ('Sophia'), ('James'), ('Emma');

INSERT INTO @surnames (surnameLocal) VALUES 
('Smith'), ('Johnson'), ('Williams'), ('Jones'), ('Brown'), ('Davis'), ('Miller'), ('Wilson'), ('Moore'), ('Taylor');

DECLARE @i INT = 1;
WHILE (@i <= 100)
BEGIN
  INSERT INTO STUDENTS (STUDENT_ID, GROUP_ID, FIRST_NAME, LAST_NAME)
  SELECT @i, FLOOR(RAND()*5)+1, nameLocal, surnameLocal
  FROM (SELECT TOP 1 nameLocal FROM @names ORDER BY NEWID()) AS n, (SELECT TOP 1 surnameLocal FROM @surnames ORDER BY NEWID()) AS s;
  SET @i = @i + 1;
END;

GO
