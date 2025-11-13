ALTER PROCEDURE [Sync].[RebuildFromSync]
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @Year INT, @Month INT, @ConfigTypeCode VARCHAR(50);

    -- Get parameters dynamically from Sync.FinalSales
    SELECT TOP 1
        @Year = CAST([Year] AS INT),
        @Month = CAST([Month] AS INT),
        @ConfigTypeCode = ConfigTypeCode
    FROM [Sync].[FinalSales]
    ORDER BY [Year] DESC, [Month] DESC;

    BEGIN TRY
        BEGIN TRANSACTION;

    --    -------------------------------------------------------
    --    -- Districts
    --    -------------------------------------------------------
    --    ;WITH DistrictMaintenance AS (
    --        SELECT DISTINCT 
    --            A.RegionCode,
    --            A.DistrictCode,
    --            A.DistrictName,
    --            A.AgentCode,
				--A.EffectivityStartDate,
				--A.EffectivityEndDate,
    --            A.IsActive
    --        FROM [Sync].[Districts] A
    --        WHERE NOT EXISTS (
    --            SELECT 1 
    --            FROM [Reports].[Districts] D
    --            WHERE D.DistrictCode = A.DistrictCode
    --              AND D.AgentCode   = A.AgentCode
    --        )
    --    )
    --    INSERT INTO [Reports].[Districts]
    --    SELECT * FROM DistrictMaintenance;

        ---------------------------------------------------------
        ---- Territories
        ---------------------------------------------------------
        --;WITH TerritoryMaintenance AS (
        --    SELECT DISTINCT 
        --        A.RegionCode,
        --        A.DistrictCode,
        --        A.TerritoryCode,
        --        A.TerritoryName,
        --        A.ConfigTypeCode
        --    FROM [Sync].[Territories] A
        --    WHERE A.ConfigTypeCode = @ConfigTypeCode
        --      AND NOT EXISTS (
        --          SELECT 1 
        --          FROM [Reports].[Territories] T
        --          WHERE T.RegionCode   = A.RegionCode
        --            AND T.DistrictCode = A.DistrictCode
        --            AND T.TerritoryCode= A.TerritoryCode
        --      )
        --)
        --INSERT INTO [Reports].[Territories]
        --SELECT * FROM TerritoryMaintenance;

        ---------------------------------------------------------
        ---- Sales Managers
        ---------------------------------------------------------
        --;WITH DistrictManagerMaintenance AS (
        --    SELECT DISTINCT 
        --        A.DistrictManagerCode,
        --        A.DistrictManagerName,
        --        A.IsActive,
        --        ''  AS EmailAddress,
        --        ''  AS IsActiveEmail,
        --        A.ConfigTypeCode
        --    FROM [Sync].[SalesManagers] A
        --    WHERE A.ConfigTypeCode = @ConfigTypeCode
        --      AND NOT EXISTS (
        --          SELECT 1 
        --          FROM [Reports].[SalesManagers] B
        --          WHERE B.DistrictManagerCode = A.DistrictManagerCode
        --            AND B.DistrictManagerName = A.DistrictManagerName
        --      )
        --)
        --INSERT INTO [Reports].[SalesManagers]
        --SELECT * FROM DistrictManagerMaintenance;

        ---------------------------------------------------------
        ---- Agents
        ---------------------------------------------------------
        --;WITH AgentMaintenance AS (
        --    SELECT DISTINCT 
        --        A.AgentCode,
        --        A.AgentName,
        --        DATEFROMPARTS(@Year, 1, 1)   AS EffectivityStartDate,
        --        DATEFROMPARTS(@Year, 12, 31) AS EffectivityEndDate,
        --        A.IsActive,
        --        'PMR'   AS PositionCode,
        --        'PROFESSIONAL MEDICAL REPRESENTATIVE' AS PositionName,
        --        A.TerritoryCode,
        --        A.TerritoryName,
        --        ''  AS EmailAddress,
        --        ''  AS IsActiveEmail,
        --        A.DistrictManagerCode,
        --        A.ConfigTypeCode
        --    FROM [Sync].[Agents] A
        --    WHERE A.ConfigTypeCode = @ConfigTypeCode
        --      AND NOT EXISTS (
        --          SELECT 1 
        --          FROM [Reports].[Agents] B
        --          WHERE B.TerritoryCode = A.TerritoryCode
        --            AND B.AgentCode     = A.AgentCode
        --    )
        --)
        --INSERT INTO [Reports].[Agents]
        --SELECT * FROM AgentMaintenance;

        ---------------------------------------------------------
        ---- Employees
        ---------------------------------------------------------
        --;WITH EmployeeMaintenance AS (
        --    SELECT DISTINCT 
        --        A.EmployeeCode,
        --        A.EmployeeName,
        --        A.Designation,
        --        A.Level
        --    FROM [Sync].[Employees] A
        --    WHERE NOT EXISTS (
        --          SELECT 1 
        --          FROM [Reports].[Employees] E
        --          WHERE E.EmployeeCode = A.EmployeeCode
        --            AND E.EmployeeName = A.EmployeeName
        --    )
        --)
        --INSERT INTO [Reports].[Employees]
        --SELECT * FROM EmployeeMaintenance;

        -------------------------------------------------------
        -- Items
        -------------------------------------------------------
        --;WITH ItemMaintenance AS (
        --    SELECT DISTINCT 
        --        A.ItemMotherCode AS ItemCode,
        --        A.ItemMotherCode,
        --        A.ItemMotherName,
        --        A.ItemBrandName,
        --        A.ItemGenericName,
        --        A.ItemGroupCode,
        --        '' AS ItemClassificationCode,
        --        A.ItemDivisionCode,
        --        '' AS DistributorCode,
        --        '' AS ItemSku
        --    FROM [Sync].[FinalSales] A
        --    WHERE A.ConfigTypeCode = @ConfigTypeCode
        --      AND A.Year = @Year
        --      AND NOT EXISTS (
        --          SELECT 1 
        --          FROM [Reports].[Items] I 
        --          WHERE I.ItemMotherCode = A.ItemMotherCode
        --      )
        --      AND A.ItemBrandName IS NOT NULL
        --)
        --INSERT INTO [Reports].[Items]
        --SELECT * FROM ItemMaintenance;

        ---------------------------------------------------------
        ---- SalesMatrix
        ---------------------------------------------------------
        --;WITH SalesMatrixMaintenance AS (
        --    SELECT 
        --         A.RegionCode
        --        ,A.DistrictCode
        --        ,A.ItemDivisionCode
        --        ,A.TerritoryCode
        --        ,A.TerritoryName
        --        ,A.AgentCode
        --        ,A.AgentName
        --        ,A.EffectivityStartDate
        --        ,A.EffectivityEndDate
        --        ,A.ConfigTypeCode
        --        ,A.EmployeeCode
        --    FROM [Sync].[SalesMatrix] A
        --    WHERE A.ConfigTypeCode = @ConfigTypeCode
        --      AND YEAR(A.EffectivityStartDate) = @Year
        --      AND NOT EXISTS (
        --          SELECT 1 
        --          FROM [Reports].[SalesMatrix] S
        --          WHERE S.RegionCode = A.RegionCode
        --            AND S.DistrictCode = A.DistrictCode
        --            AND S.ItemDivisionCode = A.ItemDivisionCode
        --            AND S.TerritoryCode = A.TerritoryCode
        --            AND S.EffectivityStartDate = A.EffectivityStartDate
        --            AND S.EffectivityEndDate = A.EffectivityEndDate
        --      )
        --)
        --INSERT INTO [Reports].[SalesMatrix]
        --SELECT * FROM SalesMatrixMaintenance;

        ---------------------------------------------------------
        ---- FinalSales
        ---------------------------------------------------------
        --;WITH FinalSales AS (
        --    SELECT *
        --    FROM [Sync].[FinalSales] A
        --    WHERE A.ConfigTypeCode = @ConfigTypeCode
        --      AND A.Year = @Year
        --      AND A.Month = @Month
        --)
        --DELETE FS
        --FROM [Reports].[FinalSales] FS
        --INNER JOIN (
        --    SELECT DISTINCT DistributorCode, ConfigTypeCode, Year, Month
        --    FROM FinalSales
        --) D
        --    ON FS.DistributorCode = D.DistributorCode
        --   AND FS.ConfigTypeCode = D.ConfigTypeCode
        --   AND FS.Year = D.Year
        --   AND FS.Month = D.Month;

        --INSERT INTO [Reports].[FinalSales]
        --SELECT * FROM FinalSales;

        ---------------------------------------------------------
        ---- TargetConfiguration (DELETE part)
        ---------------------------------------------------------

        --;WITH TargetConfigurations AS (
        --    SELECT *
        --    FROM [Sync].[TargetConfiguration] TC
        --    WHERE TC.ConfigTypeCode = @ConfigTypeCode
        --      AND TC.Year = @Year
        --)
        --DELETE T
        --FROM [Reports].[TargetConfiguration] T
        --INNER JOIN (
        --    SELECT DISTINCT ConfigTypeCode, Year, Month
        --    FROM TargetConfigurations
        --) D
        --    ON T.ConfigTypeCode = D.ConfigTypeCode
        --   AND T.Year = D.Year
        --   AND T.Month = D.Month;
        
        ---------------------------------------------------------
        ---- TargetConfiguration (INSERT part)
        ---------------------------------------------------------
        --;WITH TargetConfigurations AS (
        --    SELECT *
        --    FROM [Sync].[TargetConfiguration] TC
        --    WHERE TC.ConfigTypeCode = @ConfigTypeCode
        --      AND TC.Year = @Year
        --)
        --INSERT INTO [Reports].[TargetConfiguration] (
        --     RegionCode, DistrictCode, DistrictName, DistrictManagerCode, DistrictManagerName,
        --     TerritoryCode, TerritoryName, AgentCode, AgentName, Year, Month,
        --     ItemDivisionCode, ItemCode, ItemName, Quantity, SalesTarget,
        --     IsActive, ConfigTypeCode, EmployeeCode, EmployeeName
        --)
        --SELECT 
        --     RegionCode, DistrictCode, DistrictName, DistrictManagerCode, DistrictManagerName,
        --     TerritoryCode, TerritoryName, AgentCode, AgentName, Year, Month,
        --     ItemDivisionCode, ItemCode, ItemName, Quantity, SalesTarget,
        --     IsActive, ConfigTypeCode, EmployeeCode, EmployeeName
        --FROM TargetConfigurations;

        -------------------------------------------------------
        -- TerritoryItemTargets
        -------------------------------------------------------
        ;WITH TerritoryItemTarget AS (
            SELECT *
            FROM [Sync].[TerritoryItemTargets] A
            WHERE A.ConfigTypeCode = @ConfigTypeCode
              AND A.Year = @Year
        )
        DELETE T
        FROM [Reports].[TerritoryItemTargets] T
        INNER JOIN (
            SELECT DISTINCT ConfigTypeCode, Year, Month
            FROM TerritoryItemTarget
        ) D
            ON T.ConfigTypeCode = D.ConfigTypeCode
           AND T.Year = D.Year
           AND T.Month = D.Month;

        INSERT INTO [Reports].[TerritoryItemTargets]
        SELECT * FROM TerritoryItemTarget;

        -------------------------------------------------------
        -- Commit
        -------------------------------------------------------
        COMMIT TRANSACTION;
        PRINT 'Stage 2 completed successfully';

    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        PRINT 'Error occurred: ' + ERROR_MESSAGE();
        -- Optionally log errors here
    END CATCH;
END
GO
