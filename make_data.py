import os, sys, random, json


# get args
args = {
    "outfile_path": "./data.json",
    "pattern": "{VV[{V[V][V]}][{V}][V]}",
    "var_min": 0,
    "var_max": 100,
    "arr_size": 10,
}

_arg_type = None
for arg in sys.argv[1:]:
    if _arg_type == None: _arg_type = arg
    else:
        if _arg_type == "-o": args["outfile_path"] = arg
        if _arg_type == "-p": args["pattern"] = arg
        if _arg_type == "-vl": args["var_min"] = int(arg)
        if _arg_type == "-vu": args["var_max"] = int(arg)
        if _arg_type == "-a": args["arr_size"] = int(arg)
        _arg_type = None


# main functions
def MakeArr(pattern:str, ret_after:bool=False):
    new_arr = []
    pattern_after = ""

    # fill array
    for _ in range(args["arr_size"]):
        new_element, pattern_after = MakeElement(pattern[1:], True)
        new_arr.append(new_element)

    # return
    if ret_after: return (new_arr, pattern_after[1:])
    else: return new_arr


def MakeDic(pattern:str, ret_after:bool=False):
    new_dic = {}
    pattern_after = pattern[1:]

    # fill dictionary
    while pattern_after[0] != "}":
        new_element, pattern_after = MakeElement(pattern_after, True)
        new_dic[len(new_dic)] = new_element

    # return
    if ret_after: return (new_dic, pattern_after[1:])
    else: return new_dic


def MakeVar(pattern:str, ret_after:bool=False):
    new_var = random.randint(args["var_min"], args["var_max"])

    # return
    if ret_after: return (new_var, pattern[1:])
    else: return new_var


def MakeElement(pattern:str, ret_after:bool=False):
    if pattern[0] == "[": return MakeArr(pattern, ret_after)
    if pattern[0] == "{": return MakeDic(pattern, ret_after)
    if pattern[0] == "V": return MakeVar(pattern, ret_after)


with open(os.path.join(sys.path[0], args["outfile_path"]), 'w') as outfile:
    json.dump(MakeElement(args["pattern"]), outfile)