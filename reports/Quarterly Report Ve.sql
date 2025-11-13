

WITH Base AS (
    SELECT 
        DATEPART(QUARTER, CAST('2025-' + Month + '-01' AS DATE)) AS QuarterNum,
        SUM([Target Amount]) AS TotalTarget,
        SUM([Net Amount]) AS TotalSales
    FROM SC02File
    WHERE ConfigtypeCode = 'Y2025'
	and Year = '2025'
    GROUP BY DATEPART(QUARTER, CAST('2025-' + Month + '-01' AS DATE))
),
CurrentQ AS (
    SELECT DATEPART(QUARTER, GETDATE()) AS CurrentQuarter
)
SELECT 
    'Q' + CAST(b.QuarterNum AS VARCHAR) AS Quarter,
    CASE b.QuarterNum
        WHEN 1 THEN 'Jan, Feb, Mar'
        WHEN 2 THEN 'Apr, May, Jun'
        WHEN 3 THEN 'Jul, Aug, Sep'
        WHEN 4 THEN 'Oct, Nov, Dec'
    END AS Months,
    TotalTarget AS [Target],
    TotalSales AS [Sales],
    CASE 
        WHEN TotalTarget = 0 THEN NULL
        ELSE (TotalSales / NULLIF(TotalTarget, 0)) * 100
    END AS [Performance],
    CASE 
        WHEN b.QuarterNum < cq.CurrentQuarter THEN 'Completed'
        WHEN b.QuarterNum = cq.CurrentQuarter THEN 'Ongoing'
        ELSE 'Upcoming'
    END AS [Status]
FROM Base b
CROSS JOIN CurrentQ cq
ORDER BY b.QuarterNum


