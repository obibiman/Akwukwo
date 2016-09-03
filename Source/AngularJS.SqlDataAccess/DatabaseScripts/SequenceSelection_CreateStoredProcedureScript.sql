CREATE PROCEDURE [dbo].[sp_AngularCrudAPISequence]
@SequenceName nvarchar(50),
@SequenceValue INT OUTPUT
AS

IF @SequenceName IS NULL
   BEGIN
       PRINT 'ERROR: You must specify a sequence name to execute.'
       RETURN(1)
   END
ELSE
	BEGIN
		IF @SequenceName = 'EmployeeSequence'
			SELECT @SequenceValue = NEXT VALUE FOR dbo.EmployeeSequence;
		IF @SequenceName = 'StudentSequence'
			SELECT @SequenceValue = NEXT VALUE FOR dbo.StudentSequence;
	END
SELECT @SequenceValue