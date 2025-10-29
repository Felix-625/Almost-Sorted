# Almost-Sorted

This code first compares the input array with its sorted version to identify all positions where elements are out of order. If exactly two elements are misplaced, it suggests swapping them; if a contiguous segment can be reversed to match the sorted order, it suggests reversing that subarray. The solution outputs "yes" with the specific operation if either condition is met, otherwise it outputs "no" if the array cannot be sorted with a single swap or reverse operation.
