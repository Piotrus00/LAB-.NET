﻿namespace Lib;
public interface IBookOperations
{
    void BorrowBook(int bookId, string borrowerName);
    void ReturnBook(int bookId);
}
