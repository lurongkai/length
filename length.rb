def plural_form(word)
  dict = {
    'inch' => 'inches',
    'foot' => 'feet'
  }
  if dict.has_key? word
    dict[word]
  else
    "#{word}s"
  end
end

class Assignment
  def initialize(quantity, name, meter_quantity)
    @name = name
    @value = meter_quantity / quantity
  end
  
  def eval(env)
    env[@name] = @value
    env[plural_form(@name)] = @value
    nil
  end
end

class Value
  def initialize(quantity, name)
    @quantity = quantity
    @name = name
  end
  
  def eval(env)
    if env.has_key? @name
      @quantity * env[@name]
    else
      raise "unknown metric: #@name"
    end
  end
end

class Plus
  def initialize(left, right)
    @left = left
    @right = right
  end
  
  def eval(env)
    @left.eval(env) + @right.eval(env)
  end
end

class Minus
  def initialize(left, right)
    @left = left
    @right = right
  end
  
  def eval(env)
    @left.eval(env) - @right.eval(env)
  end
end

def parse_expression(text)
  text = text.strip
  if pos = text.rindex(/[-+]/)
    left = parse_expression(text[0...pos])
    right = parse_expression(text[(pos + 1)..-1])
    if text[pos] == '+'
      Plus.new(left, right)
    elsif text[pos] == '-'
      Minus.new(left, right)
    end
  elsif text =~ /^(\d+(\.\d+)?)\s*(\w+)$/
    Value.new($1.to_f, $3)
  else
    raise "syntax error"
  end
end

def parse(text)
  text.split("\n").reject(&:empty?).map do |line|
    line = line.strip
    if line =~ /^(\d+(\.\d+)?)\s*(\w+)\s*=\s*(\d+(\.\d+)?)\s*m(eters)?$/
      Assignment.new($1.to_f, $3, $4.to_f)
    elsif line =~ /^(\d+(\.\d+)?)\s*m(eters)?\s*=\s*(\d+(\.\d+)?)\s*(\w+)$/
      Assignment.new($4.to_f, $6, $1.to_f)
    else
      parse_expression(line)
    end
  end
end

File.open('output.txt', 'w') do |f|
  f.puts "xjia@cs.sjtu.edu.cn"
  f.puts # empty line
  env = { 'm' => 1.0, 'meters' => 1.0 }
  parse(File.read('input.txt')).each do |statement|
    result = statement.eval(env)
    f.puts "%.2f m" % result unless result.nil?
  end
end
