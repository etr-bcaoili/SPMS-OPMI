Alter  PROCEDURE [dbo].[uspSystemSequences]
	@Action VARCHAR(100) = '',
	@SequenceCode VARCHAR(50) = ''
AS

	IF @Action = 'GetSequence' BEGIN	
		DECLARE @m_Tmp VARCHAR(100) 		

		SELECT @m_Tmp = SequenceValue + 1
		FROM SystemSequences 
		WHERE SequenceCode = @SequenceCode 

		UPDATE SystemSequences
		SET SequenceValue = SequenceValue + 1
		WHERE SequenceCode = @SequenceCode

		SELECT REPLICATE('0', 10 - LEN(@m_tmp)) + @m_tmp

	END ELSE IF @Action = 'ResetSequence' BEGIN

		UPDATE SystemSequences
		SET SequenceValue = 0
		WHERE SequenceCode = @SequenceCode

	END ELSE IF @Action = 'RegisterSequence' BEGIN

		INSERT INTO SystemSequences (SequenceCode, SequenceValue)
		VALUES (@SequenceCode, 0)

	END 


