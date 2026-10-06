defmodule Solution do
  @spec min_add_to_make_valid(s :: String.t) :: integer
  def min_add_to_make_valid(s) do
    # min add, well there's two ways:
    # either ( is short or ) is short
    # since we don't need to keep track of the positions, but we do need to keep track of the moves
    # keep track in a stack, if it's a ( we need to push it, and if it's a ), we pop one off. #
    # if we pop one off and there's no stack, add 1 to the insert counter. Then add the end, add the len(stack) + insert counter
    {open, ins_counter} = s |> String.graphemes |> Enum.reduce({0, 0}, fn char, {open, ins_counter} -> 
        case char do 
            "(" -> 
                {open + 1, ins_counter}
            ")" -> 
                cond do 
                    open <= 0 -> {open, ins_counter + 1}
                    true -> {open - 1, ins_counter}
                end
            v -> {open, ins_counter + 1}
        end
    end) 
    open + ins_counter
  end
end