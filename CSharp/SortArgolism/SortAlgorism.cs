using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortArgolism
{
    /// <summary>
    /// 거품 정렬
    /// 바로 뒤의 요소가 현재 요소보다 작으면 스왑
    /// outer for loop 한번 돌때마다 가장 큰 수의 위치가 하나씩 고정
    /// O(n ^ 2)
    /// stable : 값이 동일한 요소들을 정렬한 후에 기존 순서가 보장됨
    /// </summary>
    internal class SortAlgorism
    {
        public static void BubbleSort(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = 0; j < arr.Length - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        Swap(ref arr[i], ref arr[j + 1]);
                    }
                }
            }
        }
        /// <summary>
        /// 선택 정렬
        /// 현재의 바로 뒤부터 끝까지 중에서 가장 작은 요소를 찾아서 스왑
        /// O(n ^ 2)
        /// unstable
        /// </summary>
        public static void SelectionSort(int[] arr)
        {
            int min = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                min = i;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] < arr[min])
                        min = j;
                }
                Swap(ref arr[i], ref arr[min]);
            }
        }
        /// <summary>
        /// 삽입 정렬
        /// 현재 위치보다 이전 위치들 중에서 더 큰값이 있으면 더 큰값으로 현대 위치에 덮어쓰고
        /// 덮어쓰기가 끝나면 마지막으로 덮어쓸 때 참조했던 위치에 기존 현재위치의 값을 덮어씀(스왑)
        /// O(n ^ 2)
        /// stable : 값이 동일한 요소들을 정렬한 후에 기존 순서가 보장됨
        /// </summary>
        public static void InsertionSort(int[] arr)
        {
            int j, key = 0;
            for (int i = 1; i < arr.Length; i++)
            {
                key = arr[i];
                j = i - 1;
                while (j >= 0 && arr[j] > key)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }
                arr[j + 1] = key;
            }
        }
        /// <summary>
        /// 병합 정렬
        /// 요소를 최소단위까지 나눈 후 차례대로 병합을 하면서 정렬함 Divide and conquer
        /// O(NlogN)
        /// stable : 값이 동일한 요소들을 정렬한 후에 기존 순서가 보장됨
        /// </summary>
        public static void MergeSort(int[] arr)
        {
            MergeSort(arr, 0, arr.Length - 1);
        }
        public static void MergeSort(int[] arr, int start, int end)
        {
            if (start < end)
            {
                int mid = (start + end) / 2;

                MergeSort(arr, start, mid);
                MergeSort(arr, mid + 1, end);

                Merge(arr, start, mid, end);
            }
        }
        private static void Merge(int[] arr, int start, int mid, int end)
        {
            int[] tmp = new int[end + 1];
            for (int i = 0; i < end + 1; i++)
                tmp[i] = arr[i];

            int part1 = start;
            int part2 = mid + 1;
            int index = start;

            //part1과 part2를 비교해서 정렬하면서 채워넣음
            while (part1 <= mid && part2 <= end)
            {
                if (tmp[part1] <= tmp[part2])
                {
                    arr[index++] = tmp[part1++];
                }
                else
                {
                    arr[index++] = tmp[part2++];
                }
            }

            //남은 part1들을 index위치 뒤에 쭉 이어 붙여준다.
            //정복이 끝나고 남은 part2는 원본 배열 그대로 남아있으면 타당한 위치기 때문에 따로 신경 쓸 필요 없다.
            for (int i = 0; i < mid - part1; i++)
            {
                arr[index + i] = tmp[part1 + i];
            }
        }
        /// <summary>
        /// 퀵 정렬
        /// 0(N^2)
        /// 0(NLogN)
        /// 세타(NLogN)
        /// UnStable
        /// </summary>
        public static void QuickSort(int[] arr)
        {
            QuickSort(arr, 0, arr.Length - 1);
        }
        public static void QuickSort(int[] arr, int start, int end)
        {
            if(start < end)
            {
                int p = Partition(arr, start, end);
                QuickSort(arr, start, p - 1);
                QuickSort(arr, p + 1, end);
            }
        }
        private static int Partition(int[] arr, int start, int end)
        {
            int pivot = arr[end + (start - end) / 2];

            while(true)
            {
                while (arr[start] < pivot) start++;
                while (arr[end] > pivot) end--;

                if (start < end)
                {
                    Swap(ref arr[start], ref arr[end]);
                }
                else
                {
                    return end; //return pivot index
                }
            }
        }
        /// <summary>
        /// max -                                             힙 정렬
        /// 0(N^2)
        /// shiftup heapify 시 0(NLogN)
        /// shiftdown heapify 시 0(n^2)
        /// UnStable
        /// </summary>
        private static void HeapSort(int[] arr)
        {
            //힙구조로 변환 (정렬하면서)
            //HeapifyTopDown(arr);
            HeapifyBottomUp(arr);

            //원래 구조로 변환
            InverseHeapify(arr);
        }
        // 0(NLogN)
        public static void HeapifyTopDown(int[] arr)
        {
            int end = 1;
            while(end < arr.Length)
            {
                ShiftUp(arr, 0, end++);
            }
        }
        // 0(n^2)
        public static void HeapifyBottomUp(int[] arr)
        {
            int end = arr.Length - 1;
            int current = end;

            while (current >= 0)
            {
                ShiftDown(arr, end, current);
            }
        }
        public static void InverseHeapify(int[] arr)
        {
            int end = arr.Length - 1;
            while(end > 0)
            {
                Swap(ref arr[0], ref arr[end]);
                end--; //마지막 아이템 고정
                ShiftDown(arr, end, 1);
            }
        }
        public static void ShiftUp(int[] arr, int root, int current)
        {
            int parent = (current - 1) / 2;
            while(current > root)
            {
                if (arr[current] > arr[parent])
                {
                    Swap(ref arr[current], ref arr[parent]);
                    current = parent;
                    parent = (current - 1) / 2;
                }
                else
                {
                    break;
                }
            }
        }
        public static void ShiftDown(int[] arr, int end, int current)
        {
            int parent = (current - 1) / 2;

            while(current <= end)
            {
                //오른쪽 자식이 더 크면 오른쪽으로 스왑
                if (current + 1 <= end &&
                    arr[current] < arr[current + 1])
                    current++;
                if (arr[current] > arr[parent])
                {
                    Swap(ref arr[current], ref arr[parent]);
                    parent = current;
                    current = parent * 2 + 1; //왼쪽 자식으로 감
                }
            }
        }

        private static void Swap(ref int a, ref int b)
        {
            int tmp = b;
            b = a;
            a = tmp;
        }
    }
}
