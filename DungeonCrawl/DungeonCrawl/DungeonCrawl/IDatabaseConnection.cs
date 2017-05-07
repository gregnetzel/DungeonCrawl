using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonCrawl
{
    interface IDatabaseConnection
    {
        SQLite.SQLiteConnection DbConnection();
    }
}
